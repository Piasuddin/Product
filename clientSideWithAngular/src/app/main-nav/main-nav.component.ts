import { Component} from '@angular/core';
import { AppDataService } from '../common/services/app-data.service';
@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  constructor(private dataService: AppDataService) {
  }
  ngOnInit() {
    this.dataService.isSidebarOpen = true;
  }
  onMenuClick(drawer){
      this.dataService.isSidebarOpen = !this.dataService.isSidebarOpen;
      this.dataService.setValueToShowSideNav(this.dataService.isSidebarOpen);
  }
}
