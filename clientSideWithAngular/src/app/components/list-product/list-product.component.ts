import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ProductService } from 'src/app/services/product.service';
import { AppDataService } from 'src/app/common/services/app-data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  dataSource = new MatTableDataSource();
  
  constructor(private productService: ProductService, private appDataServiece: AppDataService,
    private matSnakBar: MatSnackBar) { }

  ngOnInit() {
    if(this.appDataServiece.responseMessageData != null){
      this.matSnakBar.open(this.appDataServiece.responseMessageData.message, "Ok", {duration: 10000});
      this.appDataServiece.setValueToResponseMessageProperty(null);
    }
    this.getProductTableData();
  }
  getProductTableData(): void{
    this.productService.getTableData().subscribe((res: any)=>{
      this.dataSource.data = res.obj;
      console.log(res.obj)
    })
  }
  displayedColumns = ["sL", "productName", "category", "createdDate", "action"];
  
  onDelete(id: number){
    this.productService.delete(id).subscribe((s: any) =>{
      if(s.status == 200){        
        this.getProductTableData();
        this.matSnakBar.open(s.message, 'Ok', {
          duration: 10000,
          verticalPosition: 'top'
        })
      }
    }, e=>{
      console.log(e);
      this.matSnakBar.open(e.error.message, 'Ok', {
        duration: 10000,
        verticalPosition: 'top'
      })
    });
    console.log(id);
  }
}
