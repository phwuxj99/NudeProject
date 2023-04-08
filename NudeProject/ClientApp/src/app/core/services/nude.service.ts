import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Products } from '../models/product';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class NudeService {

  public products: Products[] = [];
  public _empList: Array<any> = [];
  public HttpBaseURL: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.HttpBaseURL = baseUrl;
  }

  GetAllData() {
    return this.http.get<Products[]>(this.HttpBaseURL + environment.API_CONTROLLER_NAME);
  }

  AddData(product: Products) {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(product);
    return this.http.post<Products[]>(environment.API_BASE_URL, body, { 'headers': headers });
  }

  DeleteData(key: number) {
    const headers = { 'content-type': 'application/json' }
   return this.http.post<Products[]>(environment.API_BASE_URL + '/delete/' + key, null, { 'headers': headers });
  }
}

