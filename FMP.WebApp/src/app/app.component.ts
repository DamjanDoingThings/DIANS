import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FindMyPharmacy';
  constructor(
    private translate: TranslateService,
    private router: Router,
) {
     translate.setDefaultLang('mk');
     translate.addLangs(['mk']);
}
}


 