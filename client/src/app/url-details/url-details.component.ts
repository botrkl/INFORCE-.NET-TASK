import { Component, OnInit } from '@angular/core';
import { ShortUrlService } from '../services/short-url.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UrlInfo } from '../models/url-info.model';

@Component({
  selector: 'app-url-details',
  standalone: true,
  imports: [HttpClientModule,CommonModule, FormsModule,HttpClientXsrfModule],
  templateUrl: './url-details.component.html',
  styleUrl: './url-details.component.css',
  providers: [ShortUrlService]
})
export class UrlDetailsComponent implements OnInit{
  urlInfo!:UrlInfo;
  constructor(private shortUrlService: ShortUrlService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => { 
      const id = params.get('id');
      if (id) { 
        this.loadUrlInfo(id); 
      } else {
        console.error('URL ID not found in the route.');
      }
    });
  }

  loadUrlInfo(id: string): void {
    this.shortUrlService.getUrlInfo(id).subscribe({
      next: (urlInfo: UrlInfo) => {
        this.urlInfo = urlInfo;
      },
      error: (error) => {
        console.error('Error fetching URL details:', error);
      }
    });
  }

}
