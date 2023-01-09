import React from "react";

import { Link } from "react-router-dom";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import "./SideNavbar.css";

function SideNavbar(props) {
  return (
    <div className="sidenavbar--container">
      <ul className="sidenavbar--menu">
        <li>
          <Link to="/ActivistRegisterFormPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Activist Register Form</label>
          </Link>
        </li>
        <li>
          <Link to="/AllCampaignsPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Campaigns</label>
          </Link>
        </li>
        <li>
          <Link to="/AllCampaignsReportPageEdit">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Campaigns Report - Edit</label>
          </Link>
        </li>
        <li>
          <Link to="/AllCampaignsReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Campaigns Report</label>
          </Link>
        </li>
        <li>
          <Link to="/AllProductsReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Products Report</label>
          </Link>
        </li>
        <li>
          <Link to="/AllTwitsReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Twits Report</label>
          </Link>
        </li>
        <li>
          <Link to="/AllUsersReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Users Report</label>
          </Link>
        </li>
        <li>
          <Link to="/AllOrdersReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">All Orders Report</label>
          </Link>
        </li>
        <li>
          <Link to="/CompanyRegisterFormPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Company Register Form</label>
          </Link>
        </li>
        <li>
          <Link to="/CreatCampaignPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Creat Campaign</label>
          </Link>
        </li>
        <li>
          <Link to="/CreatProductPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Creat Product</label>
          </Link>
        </li>
        <li>
          <Link to="/NonprofitRegisterFormPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Nonprofit Register Form</label>
          </Link>
        </li>
        <li>
          <Link to="/SpecificCampaignReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Specific Campaign Report</label>
          </Link>
        </li>
        <li>
          <Link to="/SpecificOrdersReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Specific Orders Report</label>
          </Link>
        </li>
        <li>
          <Link to="/SpecificProductsReportPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Specific Products Report</label>
          </Link>
        </li>
        <li>
          <Link to="/WaitingForAnswerPage">
            <KeyboardArrowRightIcon />
            <label className="label--sidenavbar">Waiting For Answer</label>
          </Link>
        </li>
      </ul>
    </div>
  );
}

export default SideNavbar;
