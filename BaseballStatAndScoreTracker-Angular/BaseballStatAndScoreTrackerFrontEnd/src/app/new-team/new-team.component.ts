import { Component } from '@angular/core';

@Component({
  selector: 'app-new-team',
  templateUrl: './new-team.component.html',
  styleUrl: './new-team.component.css'
})
export class NewTeamComponent {
  newTeamName: string = '';

  onSubmit() {
    // Here you can handle the form submission
    console.log("New Team Name:", this.newTeamName);
    // You can also reset the form after submission if needed
    // For example:
    // this.teamForm.resetForm();
  }
}
