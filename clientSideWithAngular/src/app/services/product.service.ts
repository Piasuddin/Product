import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Product } from '../models/product.model';

const headerOption = {
    headers: new HttpHeaders({
        'Content-Type': 'Application/json'
    })
}

@Injectable()
export class ProductService {
    baseUrl: string;
    appHost: AppHost = new AppHost();
    constructor(private _httpClient: HttpClient) {
        this.baseUrl = this.appHost.hostName + 'api/Product/';
    }
    get(): Observable<Product[]> {
        return this._httpClient.get<Product[]>(this.baseUrl);
    }
    save(data: Product): Observable<Product> {
        if (data.id > 0) {
            return this._httpClient.put<Product>(this.baseUrl , data, headerOption);
        }
        return this._httpClient.post<Product>(this.baseUrl, data, headerOption);
    }
    getById(id) {
        return this._httpClient.get(this.baseUrl + id)
    }
    delete(id) {
        return this._httpClient.delete(this.baseUrl + id)
    }
    getDetails(id: number): Observable<any> {
        return this._httpClient.get<any>(this.baseUrl + "details/" + id);
    }
    getTableData(): Observable<any> {
        return this._httpClient.get<any>(this.baseUrl + "tableData");
    }
}