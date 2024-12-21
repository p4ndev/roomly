import { Routes } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication.component';
import { InstallationComponent } from './installation/installation.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { StartupComponent } from './startup/startup.component';
import { AccessComponent } from './access/access.component';

export const setupRoutes : Routes = [
    { path: '',                 component: StartupComponent         },
    { path: 'installation',     component: InstallationComponent    },
    { path: 'access',           component: AccessComponent          },
    { path: 'authentication',   component: AuthenticationComponent  },
    { path: 'sign-out',         component: SignOutComponent         }
];