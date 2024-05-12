import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isOpen: boolean = false;
  selectedOption: string | null = null;

  ngOnInit(): void {
    // this.initMap();
  }

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  selectOption(option: string) {
    this.selectedOption = option;
    this.isOpen = false;
  }

  // async initMap(): Promise<void> {
  //   // The location of Uluru
  //   const position = { lat: -25.344, lng: 131.031 };
  //
  //   // Create a new map
  //   const map = new google.maps.Map(
  //     document.getElementById('map') as HTMLElement,
  //     {
  //       zoom: 4,
  //       center: position,
  //       // mapId: 'DEMO_MAP_ID',
  //     }
  //   );
  //
  //   // Create a marker positioned at Uluru
  //   const marker = new google.maps.Marker({
  //     position: position,
  //     map: map,
  //     title: 'Uluru'
  //   });
  // }
}
