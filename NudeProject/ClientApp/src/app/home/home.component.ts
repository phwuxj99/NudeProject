import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupByPipe } from 'ngx-pipes';
import { environment } from '../../environments/environment';
import { NudeService } from '../core/services/nude.service';
import { Products } from '../core/models/product';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [GroupByPipe]
})

export class HomeComponent {
  public products: Products[] = [];   

  public total = 0;
  private value: any;
  public total11 = 0;

  categories = [
    { id: 1, name: "Electronics" },
    { id: 2, name: "Clothing" },
    { id: 3, name: "Kitchen" }
  ];
  selectedValue = 'Electronics';
  selectedId = 1;
  itemname: string = '';
  price: number = 3000;

  constructor(public service: NudeService, private http: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.refreshList();
    //console.log(baseUrl);
  }

  save(): void {
    var product: Products = <any>{};
    product.categoryname = this.selectedValue;
    product.itemname = this.itemname;
    product.price = this.price;

    this.service.AddData(product).subscribe(result => {
      this.products = result;
      this.findsum(this.products);
    }, error => console.error(error));;

  }


  deleteData(val: number) {
    this.service.DeleteData(val).subscribe(result => {
      this.products = result;
      this.findsum(this.products);
    }, error => console.error(error));;
  }


  refreshList(): void {
    this.service.GetAllData().subscribe(result => {
      this.products = result;
      this.findsum(this.products);
    }, error => console.error(error));;
  }


  findsum(data: any) {
    //debugger
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

  onCategorySelected(event: any) {
    this.selectedId = event.target.value;
    console.log(event.target.value); 
  }

}


