import { createRouter, createWebHistory } from 'vue-router'
import CompanyList from '../companySearch/components/companyList.component.vue'
import CompanyDetail from '../companySearch/components/detailCompany.component.vue'
import LoginForm from '../userManagement/components/loginForm.component.vue'
import ClientRegistrationForm from '../userManagement/components/clientRegistrationForm.component.vue'
import CompanyRegistrationForm from '../userManagement/components/companyRegistrationForm.component.vue'
import CompanySettingsForm from '../userManagement/components/companySettingsForm.component.vue'
import ClientSettingsForm from '../userManagement/components/clientSettingsForm.component.vue'
import Home from "../public/components/home.component.vue";
import FormularyCompany from "../membership/components/formularyCompany.component.vue";
import BoletteCompany from "../membership/components/boletteCompany.component.vue";
import BookingList from "../bookingHistory/components/bookingList.component.vue";
import ToolbarClientComponent from "@/public/components/toolbarClient.component.vue";
import ToolbarCompanyComponent from "@/public/components/toolbarCompany.component.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        { path: '/', redirect: 'home'},
        { path: '/home', name: 'home', component: Home},
        { path: '/login', name: 'login', component: LoginForm},
        { path: '/register-client', name: 'register-client', component: ClientRegistrationForm},
        { path: '/register-company', name: 'register-company', component: CompanyRegistrationForm},
        // Rutas para el cliente
        {
            path: '/client/:id', component: ToolbarClientComponent,
            children: [
                { path: 'client-settings', name: 'client-settings', component: ClientSettingsForm},
                { path: 'company-search', name: 'company-search', component: CompanyList},
                { path: 'client-booking-history', name: 'client-booking-history', component: BookingList},
                { path: 'company', name: 'company-detail', component: CompanyDetail, props: true},
            ]
        },

        // Rutas para la empresa
        {
            path: '/company/:id', component: ToolbarCompanyComponent,
            children: [
                { path: 'company-settings', name: 'company-settings', component: CompanySettingsForm},
                { path: 'company-booking-history', name: 'company-booking-history', component: BookingList},
                { path: 'formulary', name: 'formulary-company', component: FormularyCompany },
                { path: 'bolette', name: 'bolette-company',
                    component: BoletteCompany,
                    props: (route) => ({
                        nombreEmpresa: route.query.nombreEmpresa,
                        ruc: route.query.ruc,
                        direction: route.query.direction,
                        tipoMembresia: route.query.tipoMembresia,
                        tipoTarjeta: route.query.tipoTarjeta,
                    })
                }
            ]
        },
        { path: '/**', redirect: 'home'}
    ]
})
export default router
