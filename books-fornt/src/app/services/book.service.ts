import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpclient: HttpClient) { }

  getAll() : Observable<Book[]> {
    return this.httpclient.get<Book[]>(apiUrl);
  }

  getById(id: number) : Observable<Book> {
    return this.httpclient.get<Book>(`${ apiUrl }/${ id }`);
  }

  create(book: Book) : Observable<Book> {
    return this.httpclient.post<Book>(apiUrl, book);
  }

  update(id: number, book: Book) : Observable<Book> {
    return this.httpclient.put<Book>(`${ apiUrl }/${ id }`, book);
  }

  delete(id: number) : Observable<Book> {
    return this.httpclient.delete<Book>(`${ apiUrl }/${ id }`);
  }
}
