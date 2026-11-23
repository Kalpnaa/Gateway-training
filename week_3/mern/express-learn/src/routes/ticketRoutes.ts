import { Router } from "express";

import {
    createTicketController,
    getAllTicketsController,
    getTicketByIdController
} from "../controllers/ticketController.js";

import checkTicketRequest from "../middleware/checkTicketRequest.js";

const router = Router();

router.post(
    "/",
    checkTicketRequest,
    createTicketController
);

router.get("/", getAllTicketsController);

router.get("/:id", getTicketByIdController);

export default router;