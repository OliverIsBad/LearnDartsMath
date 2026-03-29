export type LocalTurnEntry = {
  previousScore: number
  enteredScoredPoints: number
  enteredRemainingScore: number
  correctRemainingScore: number
  isScoreValid: boolean
  isRemainingCorrect: boolean
  isCorrect: boolean
  createdAt: string
}

export type SaveTrainingSessionRequest = {
  mode: string
  startScore: number
  finalScore: number
  isFinished: boolean
  startedAt: string
  finishedAt: string | null
  turns: LocalTurnEntry[]
}

export type SavedTrainingSessionResponse = {
  sessionId: number
}