import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ShortUrl } from "../models/short-url.model";

@Injectable({
    providedIn: 'root'
  })
  export class ShortUrlService {
    private apiUrl = 'https://localhost:7213/api/URL';
  
    constructor(private http: HttpClient) { }
  
    getAllShortUrls(): Observable<ShortUrl[]> {
      const token = localStorage.getItem('token');
      let headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`});
      return this.http.get<ShortUrl[]>(this.apiUrl + '/urls',{ headers: headers });
    }

    deleteShortUrl(id: string): Observable<void> {
      return this.http.delete<void>(`${this.apiUrl}/urls/${id}`)
    }
  }