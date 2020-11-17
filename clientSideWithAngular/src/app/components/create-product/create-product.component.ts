import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response-message.model';
import { Product } from 'src/app/models/product.model';
import { Category } from 'src/app/models/category.model';
import { ProductService } from 'src/app/services/product.service';
import { AppDataService } from 'src/app/common/services/app-data.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {
  productForm: FormGroup;
  product: Product = new Product();
  response: ResponseMessage = new ResponseMessage();
  allCategory: Category[] = [];
  constructor(private formBuilder: FormBuilder, private productService: ProductService, 
    private appDataervice: AppDataService, private matSnackBar: MatSnackBar, private router: Router,
    private categoryService: CategoryService, private activatedRoute: ActivatedRoute) { 
      this.productForm = this.formBuilder.group({
        id: '',
        name: ['', Validators.required],
        categoryId: ['', Validators.required]
      })
    }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      if(+e.get('id') > 0){
        this.productService.getById(+e.get('id')).subscribe((e: any) =>{
          this.productForm.patchValue(e.obj);
        })
      } 
    })
    this.categoryService.get().subscribe((e: any) => {
      this.allCategory = e.obj;
      console.log(e);
    })
  }
  onSubmit(){
    this.productForm.markAllAsTouched();
    if(this.productForm.valid){
      this.product = this.productForm.value;
      this.productService.save(this.productForm.value).subscribe((s: any) =>{
        if(s.status == 200){
          this.response.message = s.message;
          this.appDataervice.setValueToResponseMessageProperty(this.response);          
          this.router.navigateByUrl('/');
        }
      }, e=>{
        console.log(e);
        this.matSnackBar.open(e.error.message, 'Ok', {
          duration: 10000,
          verticalPosition: 'top'
        })
      });
    }
  }
}
