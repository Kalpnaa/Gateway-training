import {
    Request,
    Response,
    NextFunction
} from "express";

const checkTicketRequest = (
    req: Request,
    res: Response,
    next: NextFunction
) => {

    console.log("Checking ticket request");

    next();
};

export default checkTicketRequest;