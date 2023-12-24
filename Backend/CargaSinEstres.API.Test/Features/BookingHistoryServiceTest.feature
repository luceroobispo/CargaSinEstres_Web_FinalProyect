Feature: BookingsHistoryServiceTest
    As a client 
    I want to make a reservation about the services offered by the moving company so that 
    They have more details about the reservation I want.
    
    Background:
        Given the Endpoint https://localhost:7122/api/v1/bookinghistorycontroller is available

    @tutorial-adding
    Scenario: Add BookingHistory
        When a Post Request is sent
          | companyId | clientId | bookingDate | pickupAddress | destinationAddress | movingDate | movingTime | services | status     | payment |
          | 1         | 1        | dd/mm/aa    | City          | City               | dd/mm/aa   | hh:mm      | Carga    | En proceso | 0       |
        Then A Response is received with Status 200
        And a BookingHistory Resource is included in Response Body
          | Id | companyId | clientId | bookingDate | pickupAddress | destinationAddress | movingDate | movingTime | services | status     | payment |
          | 1  | 1         | 1        | dd/mm/aa    | City          | City               | dd/mm/aa   | hh:mm      | Carga    | En proceso | 0       |