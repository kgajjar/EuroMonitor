import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Toast, ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from '../../_models/member';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  //This gives us access to our template form
  @ViewChild('editForm') editForm: NgForm;
  member: Member;
  user: User;
  //If user tries to close form or go to new address
  //Show them warning
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      //This will tell browser to display it's own warning for unsaved changes.
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService, private memberService: MembersService,
    private toastr: ToastrService) {
    //Get Current User out of observable and assign it  to [user object]
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user)
  }

  ngOnInit(): void {
    //Initialise this component
    this.loadMember();
  }

  loadMember() {
    this.memberService.getMember(this.user.username).subscribe(member => this.member = member)
  }

  updateMember() {
    this.memberService.updateMember(this.member).subscribe(() => {
      //console.log(this.member);
      this.toastr.success("Profile updated successfully.");

      //Reset our edit form and preserve updated values in form.
      this.editForm.reset(this.member);
    });

  }
}
