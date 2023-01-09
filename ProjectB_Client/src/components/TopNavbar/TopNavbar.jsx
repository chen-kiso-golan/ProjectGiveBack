import React from "react";

import { Link } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import InventoryTwoToneIcon from "@mui/icons-material/InventoryTwoTone";
import "./TopNavbar.css";

function TopNavbar(props) {
  return (
    <div className="topnavbar--container">
      <ul className="topnavbar--menu">
        <li>
          <Link to="/">
            <HomeIcon />
            <label className="label--topnavbar">Logo - Home</label>
          </Link>
        </li>
        <li>
          <Link to="/AllCampaignsPage">
            <InventoryTwoToneIcon />
            <label className="label--topnavbar">All Campaigns Page</label>
          </Link>
        </li>
      </ul>
    </div>
  );
}

export default TopNavbar;
