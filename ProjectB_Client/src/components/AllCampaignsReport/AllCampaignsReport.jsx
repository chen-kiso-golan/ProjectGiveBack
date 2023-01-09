import React from "react";
import "./AllCampaignsReportStyle.css";
import { CampaignsReportRow } from "./CampaignsReportRow";

export function AllCampaignsReport(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">ID</th>
          <th scope="col">Name</th>
          <th scope="col">Email</th>
          <th scope="col">Link</th>
          <th scope="col">Hashtag</th>
          <th scope="col">Is Active</th>
          <th scope="col">Organization Name</th>
          <th scope="col">Image URL</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody className="table-group-divider">
        <CampaignsReportRow />
      </tbody>
    </table>
  );
}
