import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'products/99').subscribe(res => {
      console.log(res);
    }, error => console.log(error));
  }

  get500Error() {
    this.http.get(this.baseUrl + 'errortest/servererror').subscribe(res => {
      console.log(res);
    }, error => console.log(error));
  }

  get400Error() {
    this.http.get(this.baseUrl + 'errortest/badrequest').subscribe(res => {
      console.log(res);
    }, error => console.log(error));
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/ninetynine').subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }
}
