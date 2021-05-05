import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { MemberSubscriptions } from '../_models/member_subscriptions';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { SubscriptionService } from '../_services/subscription.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})

export class MemberSubscriptionsComponent implements OnInit {

  memberSubscriptions : MemberSubscriptions [];
  
  //Used to store single user object
  user: User;

  constructor(private memberSubscriptionsService: SubscriptionService, private accountService: AccountService) {

    //Get Current User out of observable and assign it to [user object]
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user)
  }
  //Assign data returned
  ngOnInit() : void
  {
    this.loadMember();
  }
  
  loadMember() {
    this.memberSubscriptionsService.getMemberSubscriptions(this.user.username).subscribe(sub => this.memberSubscriptions = sub);
  }
  }