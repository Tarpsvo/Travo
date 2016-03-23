import {inject} from 'aurelia-framework';
import Notify from 'notify-client';
import TeamServices from 'services/team-services';
import config from 'travo-config';

@inject(TeamServices)
export class BoardsView {
    teamServices: TeamServices;

    // View values
    teamsWithBoards: Object[];

    constructor(teamServices: TeamServices) {
        this.teamServices = teamServices;
        this.getTeamsWithBoards();
    }

    getTeamsWithBoards() {
        console.log("Getting teams with boards.");
        this.teamServices.getTeamsWithBoards()
            .then(response => {
                this.teamsWithBoards = response;
                console.log(this.teamsWithBoards);
            })
            .catch(response => {
                console.log(response);
            });
    }
}
