import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class NudeService {

  public forecasts: WeatherForecast[] = [];   
  public _empList: Array<any> = [];
  public HttpBaseURL: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.HttpBaseURL = baseUrl;
  }

  returnData(): Array<any> {
    return this._empList;
  }

  addData(item: any): void {
    this._empList.push(item);
  }

  delete(key: number): void {

  }
}

interface WeatherForecast {
  id: number;
  categoryname: string;
  itemname: string;
  price: number;
}
