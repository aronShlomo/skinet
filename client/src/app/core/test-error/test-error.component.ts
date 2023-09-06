import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { enviornment } from 'src/environments/enviornment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
     baserUrl = enviornment.apiUrl;

     constructor(private http: HttpClient){}

     get404Error(){
      this.http.get(this.baserUrl + 'product/42').subscribe({
        next: response => console.log(response),
        error: error => console.log(error)
      })
     }

     get400Error(){
      this.http.get(this.baserUrl + 'buggy/badrequest').subscribe({
        next: response => console.log(response),
        error: error => console.log(error)
      })
     }

     get400ValidationError(){
      this.http.get(this.baserUrl + 'product/fortytwo').subscribe({
        next: response => console.log(response),
        error: error => console.log(error)
      })
     }

     get500Error(){
      this.http.get(this.baserUrl + 'buggy/servererror').subscribe({
        next: response => console.log(response),
        error: error => console.log(error)
      })
     }
}
