import { Injectable } from '@angular/core';
import { Good } from '../models/good';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GoodService {

  private goodsUrl = this.getUrl('api/goods');
  private searchUrl = this.getUrl('api/goods/search');

  constructor(private messageService: MessageService,
    private http: HttpClient) { }

  getGoods(): Observable<Good[]> {
    this.messageService.add('GoodService: fetched goods');
    return this.http.get<Good[]>(this.goodsUrl).pipe(
      map(x => {

        return x;
      }),
      catchError(this.handleError<Good[]>('getGoods', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.messageService.add(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getGood(id: number): Observable<Good> {
    this.messageService.add(`GoodService: fetched good id=${id}`);
    return this.http.get<Good>(this.goodsUrl + '/' + id)
      .pipe(
        tap((x: Good) => { console.log("get good-> " + x.name) }),
        catchError(this.handleError<Good>('getGood')));
  }


  private getUrl(url: string): string {
    if (environment.apiUrl) {
      return `${environment.apiUrl}/${url}`;
    }
    return url;
  }

  addOrUpdate(g: Good) {
    if (g.id == 0) {
      this.messageService.add(`GoodService: add new  good (name: ${g.name})`);
    }
    this.messageService.add(`GoodService: update good id=${g.id}`);

    return this.http.post<void>(this.goodsUrl, g)
      .pipe(catchError(this.handleError<void>('addOrUpdate')));

  }

  delete(g: Good | number) {

    const id = typeof g === 'number' ? g : g.id;

    this.messageService.add(`GoodService: delete good id=${id}`);

    return this.http.delete<void>(this.goodsUrl + '/' + id)
      .pipe(
        catchError(this.handleError<void>('delete')));

  }

  search(trem: string): Observable<Good[]> {
    this.messageService.add('GoodService: search goods');
    return this.http.get<Good[]>(`${this.searchUrl}/?name=${trem}`).pipe(

      catchError(this.handleError<Good[]>('search', []))
    );

  }
}