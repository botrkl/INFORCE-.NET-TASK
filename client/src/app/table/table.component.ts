import { Component, OnInit } from '@angular/core';
import { ShortUrl } from '../models/short-url.model';
import { ShortUrlService } from '../services/short-url.service';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [HttpClientModule,CommonModule, FormsModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css',
  providers: [ShortUrlService]
})
export class TableComponent implements OnInit{
  shortUrls: ShortUrl[] = [];

  constructor(private shortUrlService: ShortUrlService) { }

  ngOnInit(): void {
    this.loadShortUrls();
  }

  loadShortUrls(): void {
    this.shortUrlService.getAllShortUrls().subscribe(shortUrls => {
      this.shortUrls = shortUrls;
    });
  }

  deleteShortUrl(id: string) {
    try {
      this.shortUrlService.deleteShortUrl(id);
      this.loadShortUrls();
    } catch (error) {
      console.error('Error deleting URL:', error);
    }
  }
}
