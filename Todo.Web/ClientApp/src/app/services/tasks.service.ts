import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
//{
//  providedIn: 'root'
//}

export class TaskService {

  _baseUrl = '';

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  getAll(): Observable<any> {
    return this.http.get(this._baseUrl + 'Todo/');
  }

  get(id): Observable<any> {
    return this.http.get(this._baseUrl + 'Todo/'+ id)
  }

  create(data): Observable<any> {
    return this.http.post(this._baseUrl + 'Todo/', data);
  }

  update(data): Observable<any> {
    return this.http.put(this._baseUrl + 'Todo/', data);
  }  
}
