import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  private baseUrl = environment.apiUrl;
  validationErrors: any[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'products/42')
      .subscribe(res => {

      },
        err => {

        })
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/servererror')
      .subscribe(res => {

      },
        err => {

        })
  }


  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest')
      .subscribe(res => {

      },
        err => {

        })
  }


  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/sdaofhoalj')
      .subscribe(res => {

      },
        err => {
          this.validationErrors = err.errors
        })
  }

}
