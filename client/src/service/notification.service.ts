import { MatSnackBar, MatSnackBarRef, TextOnlySnackBar } from "@angular/material/snack-bar";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class NotificationService {

    private dismissNotificationInMillis = 3000;

    constructor(private snackBar : MatSnackBar) { }

    notify = (message : string) : MatSnackBarRef<TextOnlySnackBar> => 
        this.snackBar.open(message, undefined, { duration: this.dismissNotificationInMillis });

    close = () : void => 
        this.snackBar.dismiss();

}