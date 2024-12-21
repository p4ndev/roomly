import { MenuItemDto } from "../shared/menu-item/menu-item.dto";

export const MenuItem = {
    Dashboard : <MenuItemDto>{
        href    : '/dashboard',
        label   : 'Dashboard',
        icon    : 'dashboard'
    },
    Schedule : <MenuItemDto>{
        href    : '/management/schedule',
        label   : 'Agendamento',
        icon    : 'calendar_month'
    },
    Management : <MenuItemDto>{
        href    : '/management',
        label   : 'Gerenciamento',
        icon    : 'settings'
    },
    LogOut : <MenuItemDto>{
        href    : '/setup/sign-out',
        label   : 'Desconectar',
        icon    : 'logout'
    },
};