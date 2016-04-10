import {inject} from 'aurelia-framework';
import Notify from 'services/notify-client';
import TeamServices from 'services/api/team-services';
import BoardServices from 'services/api/board-services';
import config from 'travo-config';

@inject(TeamServices, BoardServices)
export class BoardsView {
    teamServices: TeamServices;
    boardServices: BoardServices;

    // View values
    teamsWithBoards: Object[];

    constructor(teamServices: TeamServices, boardServices: BoardServices) {
        this.teamServices = teamServices;
        this.boardServices = boardServices;
        this.getTeamsWithBoards();
    }

    activate(params) {
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

    userOpenedBoardForm(index: number) {
        var input = this.getBoardFormInputFromIndex(index);

        // Enable enter press on textarea
        var that = this;
        input.onkeyup = function(e) {
            if (e.keyCode === 13 && !e.shiftKey) {
                that.createNewBoard(index);
            }
            return true;
        }

        input.focus();
        input.value = "";
    }

    createNewBoard(index: number) {
        var input = this.getBoardFormInputFromIndex(index);
        var boardName = input.value;

        if (!boardName || boardName.trim().length == 0) {
            return;
        }

        var newBoard = {
            id: 0,
            created: null,
            name: boardName
        };

        var boardsArray = (<Object[]> this.teamsWithBoards[index]['boards']);
        boardsArray.push(newBoard);
        this.closeBoardFormAtIndex(index);

        let teamId = this.teamsWithBoards[index]['team'].id;
        this.boardServices.createNewBoard(teamId, newBoard)
            .then(response => {
                newBoard.id = response.id,
                newBoard.created = response.created
            })
            .catch(error => {
                console.log("What error");
            });
    }

    // Helper methods
    getBoardFormInputFromIndex(index: number) {
        let wrapperId = 'trv-cb-form-' + index;
        let input = (<HTMLInputElement> document.getElementById(wrapperId).querySelector('input'));
        return input;
    }

    closeBoardFormAtIndex(index: number) {
        let wrapperId = 'trv-cb-form-' + index;
        let closeAnchor = document.getElementById(wrapperId).getElementsByClassName('trv-cancel-btn')[0];
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent("click", true, true);
        closeAnchor.dispatchEvent(evt);
    }
}
