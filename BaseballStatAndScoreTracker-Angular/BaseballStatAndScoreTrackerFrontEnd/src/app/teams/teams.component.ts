import { Component } from '@angular/core';
import { TeamService } from '../Services/team-service/team.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrl: './teams.component.css'
})
export class TeamsComponent {
  constructor(private teamService: TeamService,
    private router: Router
    ) {}

    addTeam(){
      console.log("add team");
      this.router.navigate(['/new-team']);
    }

}
