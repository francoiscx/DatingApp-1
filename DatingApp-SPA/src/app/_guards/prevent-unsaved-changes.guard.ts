import { Injectable } from '@angular/core';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { CanDeactivate } from '@angular/router';

@Injectable()
// tslint:disable-next-line: max-line-length
// Export the preventunsaved changes to implement the can deactivate interphase which applies to the member edit component and then add can deactivate method.
export class PreventUnsavedChanges implements CanDeactivate<MemberEditComponent>{
    // Pass component in the parameters to have access to the edit form.
    canDeactivate(component: MemberEditComponent) {
        // Validate if form is dirty or not
        if (component.editForm.dirty) {
            // return the following when clicked on another router and the form is changed
            return confirm('Are you sure you want to continue?  Any unsaved changes will be lost.')
        }
        return true;
    }
}