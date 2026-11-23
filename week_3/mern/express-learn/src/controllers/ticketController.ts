import { Request, Response, NextFunction } from "express";

import {
    createTicket,
    getAllTickets,
    getTicketById
} from "../services/ticketService.js";

import AppError from "../utils/AppError.js";

// Create ticket
export const createTicketController = (
    req: Request,
    res: Response,
    next: NextFunction
) => {

    try {

        const { title, description } = req.body;

        if (
            typeof title !== "string" ||
            typeof description !== "string" ||
            !title.trim() ||
            !description.trim()
        ) {

            throw new AppError(
                "Valid title and description are required",
                400
            );

        }

        const ticket = createTicket(title, description);

        return res.status(201).json({
            success: true,
            message: "Ticket created successfully",
            data: ticket
        });

    } catch (error) {

        next(error);

    }

};

// Get all tickets
export const getAllTicketsController = (
    req: Request,
    res: Response,
    next: NextFunction
) => {

    try {

        const status = req.query.status;

        if (status !== undefined && typeof status !== "string") {

            throw new AppError("Invalid status parameter", 400);

        }

        const tickets = getAllTickets(status);

        return res.status(200).json({
            success: true,
            count: tickets.length,
            data: tickets
        });

    } catch (error) {

        next(error);

    }

};

// Get ticket by ID
export const getTicketByIdController = (
    req: Request,
    res: Response,
    next: NextFunction
) => {

    try {

        const id = Number(req.params.id);

        if (!Number.isInteger(id) || id <= 0) {

            throw new AppError("Invalid ticket ID", 400);

        }

        const ticket = getTicketById(id);

        if (!ticket) {

            throw new AppError("Ticket not found", 404);

        }

        return res.status(200).json({
            success: true,
            data: ticket
        });

    } catch (error) {

        next(error);

    }

};