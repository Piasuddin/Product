import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Category } from '../models/category.model';

const headerOption = {
    headers: new HttpHeaders({
        'Content-Type': 'Application/json'
    })
}

@Injectable()
export class CategoryService {
    baseUrl: string;
    appHost: AppHost = new AppHost();
    constructor(private _httpClient: HttpClient) {
        this.baseUrl = this.appHost.hostName + 'api/category/';
    }
    get(): Observable<Category[]> {
        return this._httpClient.get<Category[]>(this.baseUrl);
    }
    save(data: Category): Observable<Category> {
        if (data.id > 0) {
            return this._httpClient.put<Category>(this.baseUrl + data.id, data, headerOption);
        }
        return this._httpClient.post<Category>(this.baseUrl, data, headerOption);
    }
    getById(id) {
        return this._httpClient.get(this.baseUrl + id)
    }
    deleteCategoryById(id): Observable<void> {
        return this._httpClient.delete<void>(this.baseUrl + id)
    }
}