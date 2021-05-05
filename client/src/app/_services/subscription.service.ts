import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { MemberSubscriptions } from '../_models/member_subscriptions';

//Injectable means that this service can be injected in other components/services in app
@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  //We get out APi base URL here
  baseUrl = environment.apiUrl;//get api URL from enviroment variables

  //Used to store state. Array of Member subscriptions
  memberSubscriptions: MemberSubscriptions[] = [];

  //Bring in HTTP Client 
  constructor(private http: HttpClient) { }

    //Function to get members which returns a Member array
    getMemberSubscriptions(username : string) {
      /*
      If the member array has values in it already then return values from it
      else fetch values form API and return them.
      This way we limit the amount of API calls
      of: Means we are returning something of type Observable
      */
      //if (this.memberSubscriptions.length > 0) return of(this.memberSubscriptions)//returns Observable
  
      //Else get from API
      //We will use TypeScript inference. Here we set the members inside pipe operator after getting them from API.
      return this.http.get<MemberSubscriptions[]>(this.baseUrl + 'Subscriptions/' + username).pipe(
        map(subscriptions => {
          this.memberSubscriptions = subscriptions;
          return subscriptions;//map also returns an Observable.
        })
      );
    }

}