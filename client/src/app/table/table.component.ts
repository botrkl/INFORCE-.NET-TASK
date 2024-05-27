import { Component, OnInit } from '@angular/core';
import { ShortUrl } from '../models/short-url.model';
import { ShortUrlService } from '../services/short-url.service';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [HttpClientModule,CommonModule, FormsModule,HttpClientXsrfModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css',
  providers: [ShortUrlService]
})
export class TableComponent implements OnInit{
  shortUrls: ShortUrl[] = [];
  showInput: boolean = false;
  newUrl: string = '';

  constructor(private shortUrlService: ShortUrlService,private router: Router) { }

  ngOnInit(): void {
    this.loadShortUrls();
    this.showInput = !!localStorage.getItem('token'); 
  }

  loadShortUrls(): void {
     this.shortUrlService.getAllShortUrls().subscribe(shortUrls => {
        this.shortUrls = shortUrls;
     });
     }

  deleteShortUrl(id: string) { 
    this.shortUrlService.deleteShortUrl(id).subscribe(response => {
      this.loadShortUrls(); 
    });
  }

  addShortUrl(originalUrl: string) {
    this.shortUrlService.addShortUrl(originalUrl).subscribe(response => {
      this.loadShortUrls(); 
    });
  }

  goToUrlDetails(id: string) {
    this.router.navigate(['/urls', id]);
  }
}
