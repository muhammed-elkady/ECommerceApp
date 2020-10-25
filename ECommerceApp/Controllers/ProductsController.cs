using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApp.Api.Errors;
using ECommerceApp.Api.Helpers;
using ECommerceApp.Core.Dtos;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Specifications;
using ECommerceApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            var productsDtos = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var paginatedDtos = new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, productsDtos);
            return Ok(paginatedDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepo.GetEntityWithSpec(new ProductsWithTypesAndBrandsSpecification(id));

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var productDto = _mapper.Map<Product, ProductToReturnDto>(product);
            return Ok(productDto);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetAllAsync());
        }
    }
}
