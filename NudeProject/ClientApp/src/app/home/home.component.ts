import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupByPipe } from 'ngx-pipes';
import { environment } from '../../environments/environment' ;
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [GroupByPipe]
})

export class HomeComponent {
  public forecasts: WeatherForecast[] = [];

   

  public total = 0;
  private value: any;

  public total11 = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      console.log(baseUrl);
      this.forecasts = result;
      this.findsum(this.forecasts);
    }, error => console.error(error));
  }

  save(): void {
    
    var product: WeatherForecast = <any>{};
    product.categoryname = 'Clothing';
    product.itemname = 'test name';
    product.price = 25;

    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(product);
    console.log(body);
    this.http.post<WeatherForecast[]>(environment.API_BASE_URL, body, { 'headers': headers }).subscribe(result => {
      this.forecasts = result;
      this.findsum(this.forecasts);
    }, error => console.error(error));

  }


  refreshList(): void {
    this.http.get<WeatherForecast[]>('https://localhost:44435/weatherforecast/int/7').subscribe(result => {

      console.log('refresh list');
      this.forecasts = result;
      this.findsum(this.forecasts);
    }, error => console.error(error));
  }


  findsum(data: any) {
    debugger
    this.value = data
    console.log(this.value);
    for (let j = 0; j < data.length; j++) {
      this.total += this.value[j].price
      console.log(this.total)
    }
  }

  public locationsSum(data: any) {
    this.total11 = 0;
    this.value = data
    console.log(this.value);
    for (let j = 0; j < data.length; j++) {
      this.total11 += this.value[j].price
      console.log(this.total11)
    }
    return this.total11;
  }



}

interface WeatherForecast {
  id: number;
  categoryname: string;
  itemname: string;
  price: number;
}

