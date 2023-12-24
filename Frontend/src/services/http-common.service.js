import http from '../shared/services/http-common';

export class HttpCommonService{

    // company controller
    createCompany(data){
        return http.post('/companies/sign-up', data);
    }
    getCompaniesForLogin(data){
        return http.post( `/companies/sign-in`,data);
    }
    getAll() {
        return http.get('/companies');
    }
    getById(workerId) {
        return http.get(`/companies/${workerId}`);
    }
    updateCompany(id, data) {
        return http.patch(`/companies/${id}`, data);
    }

    // client controller
    createClient(data){
        return http.post('/clients/sign-up', data);
    }
    getClientsForLogin(data){
        return http.post( `/clients/sign-in`,data);
    }
    // get all clients
    getClientById(id) {
        return http.get(`/clients/${id}`);
    }
    updateClient(id, data) {
        return http.patch(`/clients/${id}`, data);
    }
    getWorkerById(id){
        return http.get(`/workers/${id}`);
    }

    updateWorkerComment(id, data) {
        return http.patch(`/workers/${id}/comments`, data);
    }


    // booking history controller
    createReservation(clientId, companyId, data) {

        return http.post(`/booking-history?clientId=${clientId}&companyId=${companyId}`, data);
    }
    getAllBookings() {
        return http.get('/booking-history');
    }
    getBookingsByClient(id) {
        return http.get(`/booking-history/idClient/${id}`);
    }
    getBookingsByCompany(id) {
        return http.get(`/booking-history/idCompany/${id}`);
    }
    updateBooking(id, data) {
        return http.patch(`/booking-history/${id}`, data);
    }

    //chat
    createMessage(id, data){
        return http.put(`/booking-history/${id}/messages`, data);
    }
    // reviews controller
    addReview(companyId,review) {
        return http.post(`/reviews?companyId=${companyId}`, review);
    }
    getReviews() {
        return http.get('/reviews')
    }

    //membership
    createMembership(data){
        return http.post('/memberships', data);
    }

    getAllMemberships(){
        return http.get('/memberships');
    }

}
