import { Component, OnInit } from '@angular/core';
import { AppServiceService } from '../app-service.service';

@Component({
  selector: 'app-footer',
  templateUrl: './app-footer.component.html',
  styleUrls: ['./app-footer.component.css']
})
export class AppFooterComponent implements OnInit {

  currentYear: number;
  constructor(public appService: AppServiceService) { }

  ngOnInit(): void {
    const dateObj = new Date();
    this.currentYear = dateObj.getFullYear();
  }

}
