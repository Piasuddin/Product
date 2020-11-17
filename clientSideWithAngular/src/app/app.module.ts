import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { MaterialModule } from './Material/material.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateProductComponent } from './components/create-product/create-product.component';
import { ListProductComponent } from './components/list-product/list-product.component';
import { ProductService } from './services/product.service';
import { CategoryService } from './services/category.service';
import { AppDataService } from './common/services/app-data.service';
import { DashboardComponent } from './home/components/dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    CreateProductComponent,
    ListProductComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ProductService, CategoryService, AppDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
