import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PharmacyDistanceData } from '../models/PharmacyDistanceData';
import { Coordinate } from '../models/Coordinate';
import { environment } from 'src/environments/environment';



@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  @ViewChild('keyword', { static: true }) usernameElement!: ElementRef;
  searchKeyword: string = '';
  pharmacies = Array<PharmacyDistanceData>();
  name = 'Angular';
  lat: any;
  lng: any;

  constructor(private http: HttpClient) {


  }
  ngOnInit(): void {

  }
  async searchTerm() {
    let keyWord = this.searchKeyword;
    let userLocation = await this.getLocation() as GeolocationPosition;
    var originString = userLocation.coords.latitude + "," + userLocation.coords.longitude
    var query = "?origin="+originString+"&drugKeyword=" + keyWord;
    this.http.get<PharmacyDistanceData[]>(environment.apiUrl+"/Pharmacy/FindClosest"+query)
      .subscribe((x) => {
        console.log(x);
        this.pharmacies = x.slice(0, 5);
        console.log(this.pharmacies);
      });
  }

  // getGoogleMapsPin(coord: Coordinate) {
  //   return 'http://www.google.com/maps/place/'+coord.latitude+','+coord.longitude;
  // }

  getGoogleMapsPin(coord: string) {
    return 'http://www.google.com/maps/place/'+coord;
  }

  async getLocation() {
    if (navigator.geolocation) {

      return await new Promise<GeolocationPosition | GeolocationPositionError | null>((resolve, reject) => {
        navigator.geolocation.getCurrentPosition((position: GeolocationPosition) => {
          if (position) {
           
            this.lat = position.coords.latitude;
            this.lng = position.coords.longitude;

            resolve(position);
          }
          resolve(null);
        },
          (error: GeolocationPositionError) => {
            console.log(error)
            resolve(null);
          });
      });
    } else {
      alert("Geolocation is not supported by this browser.");
    }

    return null;

  }


}





