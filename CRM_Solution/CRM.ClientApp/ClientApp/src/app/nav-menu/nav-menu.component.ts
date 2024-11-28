import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  navigateTo(page: string) {
    // Logic to navigate to the specified page
    // This could use Angular's Router service
  }

  onLinkClick(page: string) {
    this.navigateTo(page);
  }
}
