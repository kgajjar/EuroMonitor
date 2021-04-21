import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of } from 'rxjs/internal/observable/of';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';

//Injectable means that this service can be injected in other components/services in app
@Injectable({
  providedIn: 'root'
})
export class MembersService {

  //Make request to Login endpoint
  baseUrl = environment.apiUrl;//get api URL from enviroment variables

  //Used to store state. Array of Members
  members: Member[] = [];

  //Bring in HTTP Client 
  constructor(private http: HttpClient) { }

  //Function to get members which returns a Member array
  getMembers() {
    /*
    If the member array has values in it already then return values from it
    else fetch values form API and return them.
    This way we limit the amount of API calls
    of: Means we are returning something of type Observable
    */
    if (this.members.length > 0) return of(this.members)//returns Observable

    //Else get from API
    //We will use TypeScript inference. Here we set the members inside pipe operator after getting them from API.
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map(members => {
        this.members = members;
        return members;//map also returns an Observable.
      })
    );
  }

  getMember(username: string) {

    //Attempt to get member from our members in array before trying service
    const member = this.members.find(x => x.appUserName === username);

    if (member !== undefined) return of(member);
    //If we cant find the member then we will make our API call.
    return this.http.get<Member>(this.baseUrl + 'users/' + username)
  }

  updateMember(member: Member) {
    //When we update our member, we need to update it in member[] as well, so that
    //when accessing it, we dont need to make API call again to fetch updated record from DB.
    return this.http.put(this.baseUrl + 'users', member).pipe(
      //Upon return, get member obj that we are persisting to DB.
      //Update the member[] with it.
      map(() => {
        const index = this.members.indexOf(member);
        //Set this = member[] being sent into function
        this.members[index] = member;
      })
    )
  }

}
