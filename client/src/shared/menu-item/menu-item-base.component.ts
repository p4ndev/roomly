import { MenuItem } from "../../data/menu-item.const";

export abstract class MenuItemBase{
    get menuItemModel() : typeof MenuItem{
      return MenuItem;
    }
}