import { Navigation } from "./navigation";
import { HttpHeaders } from '@angular/common/http';

export interface SelectValue {
    value: any;
    text: string;
};

export class Constants {
  public static API_ENDPOINT: string = '/';

  public static MESSAGE_ROW_CREATED = 'Record successfully created!';
  public static MESSAGE_ROW_UPDATED = 'Record successfully updated!';
  public static MESSAGE_ROW_DELETED = 'Record successfully deleted!';
  public static MESSAGE_ROW_ERROR = 'A serious error occurred, please check the console!';

  public static HTTP_OPTIONS: any = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  public static ROW_STATUS: SelectValue[] = [
      {value: 'A', text: 'Active'},
      {value: 'I', text: 'Inactive'}
  ];

  public static NAV_ITEMS: Navigation[] = [
    {
      displayName: 'Home', iconName: 'home', route: '', children: []
    },
    {
      displayName: 'General',
      iconName: 'settings',
      route: 'general',
      children: [
        { displayName: 'Value List', iconName: 'list', route: 'general/value-list', children: [] },
      ]
    },
    {
      displayName: 'Test Page',
      iconName: 'science',
      route: 'test',
      children: [
        { displayName: 'Dashboard', iconName: 'dashboard', route: 'test/dashboard', children: [] },
        { displayName: 'Drag & Drop', iconName: 'drag_indicator', route: 'test/drag-drop', children: [] },
        { displayName: 'Form', iconName: 'dynamic_form', route: 'test/form', children: [] },
        { displayName: 'Table', iconName: 'table_view', route: 'test/table', children: [] },
        { displayName: 'Tree', iconName: 'account_tree', route: 'test/tree', children: [] }
      ]
    }
  ];
}