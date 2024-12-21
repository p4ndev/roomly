import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { appConfig } from './app.config';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));

//import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

// platformBrowserDynamic()
//   .bootstrapModule(AppModule, { ngZoneEventCoalescing: true })
//     .catch(err => console.error(err));
