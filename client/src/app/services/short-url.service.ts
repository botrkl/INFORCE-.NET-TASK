import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ShortUrl } from "../models/short-url.model";
import { UrlInfo } from "../models/url-info.model";

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

    addShortUrl(originalUrl: string) {
      const token = localStorage.getItem('token');
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      });
      return this.http.post(`${this.apiUrl}/add`, JSON.stringify(originalUrl),{ headers });
    }
    
    deleteShortUrl(id: string) {
      return this.http.delete(`${this.apiUrl}/${id}`);
    }

    getUrlInfo(id:string) : Observable<UrlInfo>{
      const token = localStorage.getItem('token');
      let headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`});
        console.log("1");
      return this.http.get<UrlInfo>(`${this.apiUrl}/${id}`,{ headers: headers });
    }
  }