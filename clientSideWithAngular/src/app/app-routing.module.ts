import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { DashboardComponent } from './home/components/dashboard/dashboard.component';
import { CreateProductComponent } from './components/create-product/create-product.component';
import { ListProductComponent } from './components/list-product/list-product.component';

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'create-product', component: CreateProductComponent},
  {path: 'create-product/:id', component: CreateProductComponent},
  {path: 'product-list', component: ListProductComponent},
  {path: '**', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,  {preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
