import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AppHost } from 'src/app/common/models/app-host.model';
import { AppDataService } from 'src/app/common/services/app-data.service';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';
declare const carouselEvent: any;
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  isOpenSideNav: boolean = true;
  product: Product[] = [];
  t = [ 1, 2, 3]
  appHost: AppHost = new AppHost();

  constructor(private router: Router, private productService: ProductService, private dataService: AppDataService) { }

  ngOnInit() {
    
  }
}
