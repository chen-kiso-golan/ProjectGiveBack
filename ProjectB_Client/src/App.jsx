import React from "react";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { AllOrdersReportPage, HomePage, AboutPage, AllCampaignsPage, ContactUsPage, ActivistRegisterFormPage, AllCampaignsReportPageEdit, AllCampaignsReportPage, AllProductsReportPage, AllTwitsReportPage, AllUsersReportPage, CompanyRegisterFormPage, CreatCampaignPage, CreatProductPage, NonprofitRegisterFormPage, SpecificCampaignReportPage, SpecificOrdersReportPage, SpecificProductsReportPage, WaitingForAnswerPage } from "./pages/pagesIndex";
import TopNavbar from "./components/TopNavbar/TopNavbar";
import SideNavbar from "./components/SideNavbar/SideNavbar";
import ButtomNavbar from "./components/ButtomNavbar/ButtomNavbar";

function App() {
  return (
    <div className="App">
      <div>
        <header>
          <TopNavbar />
        </header>
        <div className="app--body">
          <div className="app--sidebar">
            <SideNavbar />
          </div>
          <div className="app--pageContent">
            <Routes>
              <Route path="/" element={<HomePage />}></Route>
              <Route path="/AllCampaignsPage" element={<AllCampaignsPage />}></Route>
              <Route path="/ContactUsPage" element={<ContactUsPage />}></Route>
              <Route path="/AboutPage" element={<AboutPage />}></Route>
              <Route path="/ActivistRegisterFormPage" element={<ActivistRegisterFormPage />}></Route>
              <Route path="/AllCampaignsReportPageEdit" element={<AllCampaignsReportPageEdit />}></Route>
              <Route path="/AllCampaignsReportPage" element={<AllCampaignsReportPage />}></Route>
              <Route path="/AllProductsReportPage" element={<AllProductsReportPage />}></Route>
              <Route path="/AllTwitsReportPage" element={<AllTwitsReportPage />}></Route>
              <Route path="/AllUsersReportPage" element={<AllUsersReportPage />}></Route>
              <Route path="/AllOrdersReportPage" element={<AllOrdersReportPage />}></Route>
              <Route path="/CompanyRegisterFormPage" element={<CompanyRegisterFormPage />}></Route>
              <Route path="/CreatCampaignPage" element={<CreatCampaignPage />}></Route>
              <Route path="/CreatProductPage" element={<CreatProductPage />}></Route>
              <Route path="/NonprofitRegisterFormPage" element={<NonprofitRegisterFormPage />}></Route>
              <Route path="/SpecificCampaignReportPage" element={<SpecificCampaignReportPage />}></Route>
              <Route path="/SpecificOrdersReportPage" element={<SpecificOrdersReportPage />}></Route>
              <Route path="/SpecificProductsReportPage" element={<SpecificProductsReportPage />}></Route>
              <Route path="/WaitingForAnswerPage" element={<WaitingForAnswerPage />}></Route>
            </Routes>
          </div>
        </div>
        <footer>
          <ButtomNavbar />
        </footer>
      </div>
    </div>
  );
}

export default App;
