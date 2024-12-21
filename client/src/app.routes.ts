import { memberGuard } from './guard/member.guard';
import { Routes } from '@angular/router';

export const appRoutes : Routes = [
    { 
        path            : 'setup',
        loadChildren    : () => import('./pages/setup/setup.module').then(m => m.SetupModule) 
    },
    {
        path            : 'dashboard',
        canActivate     : [memberGuard],        
        loadChildren    : () => import('./pages/dashboard/dashboard.module').then(d => d.DashboardModule) 
    },
    {
        path            : '',
        redirectTo      : 'setup',
        pathMatch       : 'full'
    }
];