import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  public orgName = 'Organisation Name';
  public footerText = 'Org Name - All Right Reserved';
  constructor() { }
}
